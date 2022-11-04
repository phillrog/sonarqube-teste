# sonarqube-teste

# Como rodar ?

### Executar o docker-compose para subir o container do sonarqube e o banco postgres e configurar o sysctl assim:

* vm.max_map_count=262144
* fs.file-max=65536

# Criar Projeto no sonar

### - Informar descrição e chave

![image](https://user-images.githubusercontent.com/8622005/199852197-359a0321-dd99-49fd-9a61-966de823e88a.png)

### - Informar um token

![image](https://user-images.githubusercontent.com/8622005/199852256-084f3712-0bd5-4cf5-af48-9c834f770ec2.png)

### - Após gerar ficará parecido assim

![image](https://user-images.githubusercontent.com/8622005/199852307-a30b6329-f76a-49a5-8a7c-b579260b0e51.png)

### - Executar os comandos para subir dados no sonar

![image](https://user-images.githubusercontent.com/8622005/199852413-2053d793-a43a-4a5e-9d5b-5aba384772c7.png)

# - Exemplo

```dotnet sonarscanner begin /k:"calculadora" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="e36c11afc5282d5796ec6028aa55fa8b888b1824"```

---

```dotnet build --configuration Release```

---

```dotnet test .\Calculadora.Tests\Calculadora.Tests.csproj --collect:"XPlat Code Coverage" --results-directory ./coverage```

---

```reportgenerator "-reports:./coverage/*/coverage.cobertura.xml" "-targetdir:coverage" "-reporttypes:SonarQube"```

---

```dotnet sonarscanner end /d:sonar.login="e36c11afc5282d5796ec6028aa55fa8b888b1824"```


![image](https://user-images.githubusercontent.com/8622005/199854931-f4d61d48-4891-426a-9abe-14f462c76454.png)


