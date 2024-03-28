#!/bin/bash
#https://stackoverflow.com/questions/43394775/cannot-run-npm-in-a-shell-script
docker start postgis_db_container_5455 #now 11/20/2023 working the database in cloud
xfce4-terminal --tab -e "bash -c 'cd ./WebApp; dotnet watch; bash'" 
xfce4-terminal --tab -e "bash -c 'cd ./ApiServer; dotnet watch; bash'" 
#xfce4-terminal  --tab -e "bash -c 'cd ./ES6Mapping; PATH="/home/mint20/.nvm/versions/node/v16.20.0/bin:$PATH" npm run dev; bash'" 
#xfce4-terminal  --tab -e "bash -c 'cd ./ES6Mapping; . ~/.nvm/nvm.sh; npm run dev; bash'"