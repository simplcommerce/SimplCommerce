# simplcommerce with sqlite
You can make the build locally with `./simpl-build-sqlite.sh`
Then create the container: `docker build --rm -t simplcommerce-sqlite -f Dockerfile-sqlite .  `

# simplcommerce with postgres
You can make the build locally with `./simpl-build.sh`
Before running the build make sure you have an instance of postgres up and running. Depending on your goal you can persist the data by mounting a volume or not. Here a sample way to achieve it
## Persisting Data
`mkdir ${HOME}/postgres-data/`
`docker run -d --name postgres -e POSTGRES_PASSWORD=postgres -v ${HOME}/postgres-data/:/var/lib/postgresql/data -p 5432:5432 postgres`
## Data inside container. Recreate it as you want.
`docker run -d --name postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 postgres`

### Routing simpldb to localhost or wherever the DB is running
An easy hack for calling (finding) the dabase under the name `simpledb` we make a change in the hosts file of the OS.
> For localhost we do a mapping in /etc/hosts
`127.0.0.1       simpldb`
## Build the container
`docker build --rm -t simplcommerce -f Dockerfile .  `

# Docker Compose with Simplecommerce, Postgres & PgAdmin 
So you can test docker compose, the images are already created. You only need `docker` and `docker-compose`.


## Docker-compose commands
> build the app with clean DB
docker-compose up 
> In detached mode
docker-compose up -d

> Gracefully shutdown (persisting data)
docker-compose down

> Destroy data (clean DB) 
docker-compose down -v

## For Kubernetes is just the name of the service exposing postgresql in the same namespace


### Run postgre container for dev pourpouses standard ports on localhost (mount a postrgres-data directory for the Database)
`mkdir ${HOME}/postgres-data/`
`docker run -d --name postgres -e POSTGRES_PASSWORD=postgres -v ${HOME}/postgres-data/:/var/lib/postgresql/data -p 5432:5432 postgres`
###

### Run PGAdming to access the UI and do dbadmin stuff 
`docker run -p 8080:80 -e 'PGADMIN_DEFAULT_EMAIL=user@domain.local' -e 'PGADMIN_DEFAULT_PASSWORD=SuperSecret' --name pgadmin -d dpage/pgadmin4`

Without docker-compose or defining a network you need to type the internal IP of the container so pgamin can connect it usually is something like 172.17.0.2 under IPAddress 
`docker inspect postgres -f "{{json .NetworkSettings.Networks }}"`
