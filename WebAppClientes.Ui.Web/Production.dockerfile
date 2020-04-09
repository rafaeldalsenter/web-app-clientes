FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-buster-slim
WORKDIR /app
COPY . .
EXPOSE 80
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh