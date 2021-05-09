#!/bin/bash

# Swarm mode using Docker Machine

# create manager machines
echo "======> Leave swarm mode  $managers manager machines ...";
echo "======> stop swarm-$node machine ...";
docker-machine ssh manager  "docker swarm leave -f";
docker-machine ssh manager  "docker stack rm tragatelabs";
docker-machine ssh manager  "docker network rm tragatelabs_webnet";

# create worker machines
echo "======> Leave swarm mode  $workers worker machines ...";
echo "======> stop swarm-$node machine ...";
docker-machine ssh worker1  "docker swarm leave -f";