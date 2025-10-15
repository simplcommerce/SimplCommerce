#!/usr/bin/env bash
set -euo pipefail

# Configuration (can be overridden by environment)
: "${DB_HOST:=simpldb.cluster-cne8sm0g84jd.us-west-1.rds.amazonaws.com}"
: "${DB_PORT:=5432}"
: "${DB_USER:=postgres}"
: "${DB_NAME:=simpldb}"

# PGPASSWORD should be provided via environment (Dockerfile already sets PGPASSWORD)
export PGPASSWORD

PG_IS_READY_MAX_WAIT=${PG_IS_READY_MAX_WAIT:-60}
PG_IS_READY_INTERVAL=${PG_IS_READY_INTERVAL:-2}

echo "Waiting for PostgreSQL at ${DB_HOST}:${DB_PORT} to become available..."
elapsed=0
while ! pg_isready -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" >/dev/null 2>&1; do
	sleep "$PG_IS_READY_INTERVAL"
	elapsed=$((elapsed + PG_IS_READY_INTERVAL))
	if [ "$elapsed" -ge "$PG_IS_READY_MAX_WAIT" ]; then
		echo "Timed out waiting for PostgreSQL at $DB_HOST:$DB_PORT" >&2
		exit 1
	fi
done

echo "Postgres is available. Checking for database '$DB_NAME'..."

# Check whether the database exists using a reliable query
DB_EXISTS=$(psql -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" -tAc "SELECT 1 FROM pg_database WHERE datname='$DB_NAME';")

if [ "$DB_EXISTS" = "1" ]; then
	echo "Database '$DB_NAME' exists"
else
	echo "Database '$DB_NAME' does not exist — creating and seeding"
	psql -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" -c "CREATE DATABASE \"$DB_NAME\" WITH ENCODING 'UTF8';"

	if [ -f /app/dbscript.sql ]; then
		echo "Applying /app/dbscript.sql to $DB_NAME"
		# Exit on any error while applying the SQL script
		psql -h "$DB_HOST" -p "$DB_PORT" -U "$DB_USER" -d "$DB_NAME" -v ON_ERROR_STOP=1 -f /app/dbscript.sql
	else
		echo "No dbscript.sql found at /app/dbscript.sql — skipping seeding"
	fi
fi

echo "Starting application..."

cd /app
# exec to replace shell with the dotnet process (proper signal handling)
exec dotnet SimplCommerce.WebHost.dll