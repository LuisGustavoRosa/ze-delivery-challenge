# ze-delivery-challenge

## Descrição
Desafio técnico para cadastro e busca de parceiros (PDVs) com área de cobertura geográfica, utilizando .NET 9.

## Requisitos
- .NET 9
- Docker (opcional)

## Como rodar localmente

### Usando .NET CLI
```bash
dotnet build

dotnet run --project ze-delivery-challenge/ze-delivery-challenge.csproj
```

### Usando Docker
```bash
docker build -t ze-delivery-challenge .
# Para conectar ao banco local, ajuste a string conforme seu banco
# Exemplo para SQL Server local:
docker run -p 8080:8080 -e ConnectionStrings__DefaultConnection="Server={{ip}};Port=5432;Database=zedeliverychallenge;User Id=postgres;Password=postgres;" zedeliverychallenge
```

## Endpoints principais
- `POST /partners` — Cadastra um novo parceiro
- `GET /partners` — Lista todos os parceiros
- `GET /partners/{id}` — Busca parceiro por ID
- `GET /partners/nearest?lng={longitude}&lat={latitude}` — Busca o parceiro mais próximo que cobre a localização

## Exemplo de payload para cadastro
```json
{
  "tradingName": "Adega da Cerveja - Pinheiros",
  "ownerName": "Zé da Silva",
  "document": "1432132123891/0001",
  "coverageArea": {
    "type": "MultiPolygon",
    "coordinates": [
      [[[30, 20], [45, 40], [10, 40], [30, 20]]],
      [[[15, 5], [40, 10], [10, 20], [5, 10], [15, 5]]]
    ]
  },
  "address": {
    "type": "Point",
    "coordinates": [-46.57421, -21.785741]
  }
}
```

## Contribuição
Pull requests são bem-vindos. Para grandes mudanças, abra uma issue primeiro para discutir o que você gostaria de modificar.

## Licença
MIT
