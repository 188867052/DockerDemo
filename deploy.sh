#!/bin/bash

echo start
docker pull 542153354/dockerdemo:v1.0 
docker run --name dockerdemocontainer-it -p 8080:80 542153354/dockerdemo:v1.0 /bin/sh 
logout
echo end

