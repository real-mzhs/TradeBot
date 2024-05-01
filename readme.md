## User Service Docker deployment:

### Step 1: Pulling the Service from Docker Hub
First, pull the Docker image for the service from Docker Hub using the following command:
```
docker pull mzdevi/tradebot-userservice:latest
```

### Step 2: Pulling PostgreSQL Image
Next, pull the PostgreSQL Docker image using the following command:
```
docker pull postgres:latest
```

### Step 3: Running Containers
Now that you have both images downloaded, you can run containers for the service and PostgreSQL.
```
docker run --name postgres-usersevice -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=secret_password -p 5432:5432 -d postgres
```
```
docker run -d --name tradebot-userservice -p 8080:8080 mzdevi/tradebot-userservice:latest
```

### Step 4: Verifying Containers
To verify that both containers are running, use the following command:
```
docker ps
```
