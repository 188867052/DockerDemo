#!/bin/bash

echo start
sudo docker pull 542153354/dockerdemo:v1.0 
sudo docker run --name dockerdemocontainer -d -p 8080:80 542153354/dockerdemo:v1.0 /bin/sh 
echo end

exit 0
