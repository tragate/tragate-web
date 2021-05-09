
FROM microsoft/aspnetcore:latest
LABEL Name=tragate-web Version=0.0.1
ARG source=.
WORKDIR /app
EXPOSE 5001
COPY $source .
ENTRYPOINT dotnet Tragate-UI.dll
