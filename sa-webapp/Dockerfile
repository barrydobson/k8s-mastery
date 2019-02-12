FROM microsoft/dotnet:2.2-sdk As build
WORKDIR /app
COPY ./sa-webapp/sa-webapp.csproj .
RUN ["dotnet", "restore"]
COPY ./sa-webapp .
RUN dotnet publish -c Release -o ./output

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/output .
ENTRYPOINT ["dotnet", "sa-webapp.dll"]