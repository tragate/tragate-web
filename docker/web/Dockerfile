FROM microsoft/aspnetcore:latest
ARG source
WORKDIR /app
COPY app/publish /app
COPY setup.sh /app
RUN chmod +x /app/setup.sh
EXPOSE 5001/tcp
ENV ASPNETCORE_URLS http://*:5001
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["/app/setup.sh"]