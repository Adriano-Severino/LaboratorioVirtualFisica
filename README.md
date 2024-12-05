# Simulador de Movimento de Partículas

Este projeto é um simulador de movimento de partículas que calcula e visualiza a posição e velocidade de uma partícula ao longo do tempo, considerando diferentes condições de atrito. O projeto utiliza WPF para interface gráfica e Python para análise de dados, seguindo princípios de Clean Architecture.
---

## 📂 Estrutura de Pastas

O projeto está organizado em quatro camadas principais, baseadas no DDD:
````
LaboratorioVirtualFisica/
├── 1. Presentation/
│   └── ParticleMotion/
│       ├── Helpers/
│       ├── Models/
│       ├── Services/
│       ├── ViewModels/
│       ├── Views/
│       └── GerarGrafico.py
│
├── 2. Core/
│   └── LaboratorioVirtualFisica/
│       ├── Application/
│       ├── Domain/
│       ├── Infrastructure/
│       └── Presentation/
│
└── 3. Test/
    └── LaboratorioVirtualFisica.Test/
        └── Domain/
            └── Services/
                └── PhysicsServiceTests.cs
````
````
1. Presentation (ParticleMotion)
  . Interface gráfica WPF e visualização de dados
  . Implementação do padrão MVVM
  . Script Python para geração de gráficos

2. Core (LaboratorioVirtualFisica)
 . Application: Casos de uso e lógica de aplicação
 . Domain: Regras de negócio e entidades
 . Infrastructure: Implementações técnicas
 . Presentation: Componentes de apresentação compartilhados

3. Test
 . Testes unitários para validação da lógica de física
 . Testes de serviços do domínio

````
## 🛠️ Funcionalidades
````
O simulador oferece:
 . Cálculo de posição e velocidade com e sem atrito
 . Visualização gráfica dos resultados usando WPF
 . Geração de gráficos comparativos usando Python
 . Exportação de dados para análise
````
## 🚀 Tecnologias Utilizadas

 - WPF: Interface gráfica
 - LiveCharts: Biblioteca para gráficos em WPF
 - Python: Análise de dados e geração de gráficos
 - matplotlib: Biblioteca Python para visualização de dados


## 📊 Visualização de Dados
 - O projeto oferece duas formas de visualização:
 - Gráficos interativos em tempo real usando WPF
 - Análise detalhada usando scripts Python

## 🔧 Configuração do Ambiente

Pré-requisitos
 - Visual Studio 2022 ou superior
 - .NET 9.0
 - Python 3.x
 - Bibliotecas Python: matplotlib, pandas

Instalação
1. Clone o repositório
2. Restaure os pacotes NuGet
3. Instale as dependências Python:
   ```bash
   pip install matplotlib pandas

## 📝 Uso do Sistema

1. Execute o projeto ParticleMotion
2. Insira os parâmetros da simulação:
  - Força aplicada (N)
  - Massa do objeto (kg)
  - Condição de atrito
3. Visualize os resultados nos gráficos

## 📈 Análise de Dados
Para gerar gráficos usando Python:
 1. Execute o script GerarGrafico.py
 2. Os gráficos serão gerados a partir dos dados do arquivo log.txt

## 🚀 Como Usar

### Pré-requisitos
- [.NET 9](https://dotnet.microsoft.com/) ou superior instalado na máquina.

### Passos para executar:

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/simulador-movimento.git
   cd simulador-movimento
   
2. Compile e execute o projeto:
   ```bash
   dotnet run
   
3. Insira os valores solicitados no console:
 ````
   Força aplicada (em Newtons).
   Massa da partícula (em kg).
````
4. Veja os resultados no console:
````
   . Posição e velocidade instantânea da partícula em tempos específicos (1s, 5s, 10s, 15s, 20s).
   . Velocidade média total ao final do trajeto.
````
5. Entrada:
````
  Digite a força aplicada (em Newtons): 10
  Digite a massa da partícula (em kg): 2
````
6. Saída:
````
  Com atrito
  Força aplicada de: 10 Newtons
  Massa da particula de: 2 Kgs
  ============================================================
  Tempo (s)     Posição (m)     Velocidade Instantânea (m/s)
  Tempo: 1s - Posição: 4m - Velocidade Instantânea: 4.90m/s
  Tempo: 5s - Posição: 61m - Velocidade Instantânea: 24.52m/s
  Tempo: 10s - Posição: 204m - Velocidade Instantânea: 47.05m/s
  Tempo: 15s - Posição: 428m - Velocidade Instantânea: 68.58m/s
  Tempo: 20s - Posição: 714m - Velocidade Instantânea: 90.11m/s

  Velocidade Média Total: 35.70 m/s
````
🔧 Detalhes Técnicos

Fórmulas Utilizadas
````
  1. Sem Atrito:
     . Aceleração ((a)): (a = \frac{F}{m})
     . Posição ((x)): (x = x_0 + v_0t + \frac{1}{2}at^2)
     . Velocidade ((v)): (v = v_0 + at)

  2. Com Atrito:
    . Força de atrito ((F_a)): (F_a = \mu \cdot m \cdot g)
    . Aceleração total ((a_t)): (a_t = \frac{F - F_a}{m})
````
Princípios Seguidos
````
  1. Domain-Driven Design (DDD):
    . Separação clara entre domínio, aplicação, infraestrutura e apresentação.

  2. Clean Code:
    . Nomes descritivos.
    . Métodos curtos e focados.

  3. SOLID:
    .Single Responsibility: Cada classe tem uma única responsabilidade.
    .Open/Closed: O sistema está aberto para extensão e fechado para modificação.
    .Dependency Inversion: Uso de interfaces para desacoplar dependências.

````
📜 Licença
Este projeto está licenciado sob a MIT License.

✨ Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

📞 Contato
Caso tenha dúvidas ou sugestões, entre em contato:
Nome: Adriano
Email: adriano.asx@outlook.com
GitHub: Adriano-Severino
