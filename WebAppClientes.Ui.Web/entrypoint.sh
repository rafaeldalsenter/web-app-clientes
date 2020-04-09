#!/bin/bash
run_cmd="dotnet WebAppClientes.Ui.Web.dll"

sed -i "s|{DEFAULT_CONNECTION}|$POSTGRE_CONNECTIONSTRING|g" appsettings.json

sed -i "s|{MONGO_CONNECTION}|$MONGODB_CONNECTIONSTRING|g" appsettings.json

>&2 echo "Aguardando 10 segundos para os bancos inicializarem..."
sleep 10

exec $run_cmd