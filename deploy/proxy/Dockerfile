FROM nginx:1.13.6
COPY tragate-web.conf /etc/nginx/conf.d/tragate-web.conf
COPY nginx.conf /etc/nginx/nginx.conf
RUN [ "mv", "/etc/nginx/conf.d/default.conf", "/etc/nginx/conf.d/default.conf_" ]