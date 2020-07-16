FROM node:alpine as builder
WORKDIR /sa-frontend
COPY package.json .
RUN npm install
COPY . .
ARG WEB_APP_URL=http://localhost:5051
ENV WEB_APP_URL=$WEB_APP_URL
RUN npm run build

FROM nginx:1.15-alpine
COPY --from=builder /sa-frontend/build /usr/share/nginx/html
EXPOSE 80