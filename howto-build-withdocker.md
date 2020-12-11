
## Online demo (Azure Website)
- Store front: http://demo.simplcommerce.com
- Administration: http://demo.simplcommerce.com/admin Email: admin@simplcommerce.com Password: 1qazZAQ!


## simplcommerce with sqlite
For testing purpose only `docker build --rm -t shinojosa/simplcommerce-sqlite -f Dockerfile-sqlite .  `
Continuous deployment: https://ci.simplcommerce.com


## simplcommerce with postgres
For testing purpose only `docker build --rm -t shinojosa/simplcommerce -f Dockerfile .  `
docker build --rm -t shinojosa/simplcommerce-sqlite:5 -f Dockerfile-sqlite .

# PostgreSQL Database

## Postgre containers
### Routing simpldb to localhost or wherever the DB is running
> For localhost we do a mapping in /etc/hosts
`127.0.0.1       simpldb`

> For Docker-compose (hostname in the same network )
# build the app with clean DB
docker-compose up
# Gracefully shutdown 
docker-compose down
# Destroy data (clean DB) 
docker-compose down -v

> For Kubernetes is just the name of the service exposing postgresql in the same ns


### Run postgre container for dev pourpouses standard ports on localhost (mount a postrgres-data directory for the Database)
`mkdir ${HOME}/postgres-data/`
`docker run -d --name postgres -e POSTGRES_PASSWORD=postgres -v ${HOME}/postgres-data/:/var/lib/postgresql/data -p 5432:5432 postgres`
###

### Run PGAdming to access the UI and do dbadmin stuff 
`docker run -p 8080:80 -e 'PGADMIN_DEFAULT_EMAIL=user@domain.local' -e 'PGADMIN_DEFAULT_PASSWORD=SuperSecret' --name pgadmin -d dpage/pgadmin4`

Without docker-compose or defining a network you need to type the internal IP of the container so pgamin can connect it usually is something like 172.17.0.2 under IPAddress 
`docker inspect postgres -f "{{json .NetworkSettings.Networks }}"`

## For building with PostgreSQL
Npgsql.EntityFrameworkCore.PostgreSQL 5.1.0

## For building with SQLLite
Microsoft.EntityFrameworkCore.Sqlite 5.1.0

