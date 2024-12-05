# Simulador de Movimento

Este projeto é um **simulador de movimento** que calcula a posição e a velocidade de uma partícula ao longo do tempo, considerando ou não o atrito. Ele foi desenvolvido seguindo os princípios de **Domain-Driven Design (DDD)** e **Clean Code**, garantindo modularidade, organização e facilidade de manutenção.

---

## 📂 Estrutura de Pastas

O projeto está organizado em quatro camadas principais, baseadas no DDD:
````
├── Domain/
│   ├── Entities/
│   │   └── Particle.cs
│   ├── Interfaces/
│   │   └── IPhysicsCalculator.cs
│   └── Services/
│       └── PhysicsService.cs
├── Application/
│   └── UseCases/
│       └── SimulateMovement.cs
├── Infrastructure/
│   └── Persistence/
│       └── FileLogger.cs
├── Presentation/
│   └── Controllers/
│       └── SimulationController.cs
└── Program.cs
````

### **1. Domain**
A camada **Domain** contém as regras de negócio e as abstrações principais. Ela é independente das outras camadas.

- **Entities/**:
   - Contém as entidades principais do domínio, como `Particle`.
- **Interfaces/**:
   - Define contratos para serviços que podem ser implementados em outras camadas, como `IPhysicsCalculator`.
- **Services/**:
   - Implementa a lógica principal de cálculo, como o serviço `PhysicsService`.

### **2. Application**
A camada **Application** orquestra os casos de uso da aplicação. Ela coordena a interação entre o domínio e a infraestrutura.

- **UseCases/**:
   - Contém os casos de uso, como `SimulateMovement`, que executa a simulação com base nos dados fornecidos.

### **3. Infrastructure**
A camada **Infrastructure** contém detalhes técnicos, como persistência ou integração com sistemas externos.

- **Persistence/**:
   - Implementa serviços técnicos, como `FileLogger`, para registrar logs em arquivos.

### **4. Presentation**
A camada **Presentation** gerencia a interface com o usuário ou APIs. Neste caso, usamos um controlador simples para interagir via console.

- **Controllers/**:
   - Contém controladores como `SimulationController`, que gerencia as interações com o usuário.

---

## 🛠️ Funcionalidades

O simulador calcula:
1. A posição da partícula ao longo do tempo.
2. A velocidade instantânea da partícula em momentos específicos.
3. A velocidade média total ao final do trajeto.

Além disso:
- O cálculo pode considerar ou ignorar o atrito.
- Os resultados são exibidos no console.

---

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
