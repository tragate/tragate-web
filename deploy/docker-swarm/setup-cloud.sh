#!/bin/bash

# Swarm mode using Docker Machine

# initialize swarm mode and create a manager
echo "======> Initializing first swarm manager ..."
docker-machine ssh manager "docker swarm init --listen-addr $(docker-machine ip manager) --advertise-addr $(docker-machine ip manager)"

# get manager and worker tokens
export worker_token=`docker-machine ssh manager "docker swarm join-token worker -q"`

echo "worker_token: $worker_token"

# workers join swarm
echo "======> worker1 joining swarm as worker ..."

docker-machine ssh worker1 \
"docker swarm join \
--token $worker_token \
--listen-addr $(docker-machine ip worker1) \
--advertise-addr $(docker-machine ip worker1) \
$(docker-machine ip manager)"

# show members of swarm
docker-machine ssh manager "docker node ls"

# show members of swarm
eval $(docker-machine env manager) \ 
docker stack deploy -c docker-compose.yml tragatelabs