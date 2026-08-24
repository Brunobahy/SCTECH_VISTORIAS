# AutoCheck.NET 🚗🏍️🚛

Sistema de vistoria e avaliação de veículos desenvolvido em C# e .NET.

## O que o sistema faz?

O AutoCheck.NET permite:

- Cadastrar carros, motos e caminhões;
- Realizar vistorias;
- Avaliar os itens como Bom, Regular ou Ruim;
- Calcular a pontuação da vistoria;
- Calcular o percentual de aprovação;
- Classificar o resultado da vistoria;
- Exibir recomendações de manutenção.

O projeto foi desenvolvido para praticar conceitos de Programação Orientada a Objetos utilizando C#.

---

## Como executar

### 1. Pré-requisito

É necessário ter o .NET SDK instalado.

Para verificar se está instalado:

    dotnet --version

### 2. Clonar o projeto

    git clone URL_DO_REPOSITORIO

### 3. Entrar na pasta do projeto

    cd autocheck-dotnet

### 4. Restaurar as dependências

    dotnet restore

### 5. Entrar na pasta da aplicação

    cd src/AutoCheck.ConsoleApp

### 6. Executar o programa

    dotnet run

Após executar o comando, o sistema será iniciado diretamente no terminal.

---

## Regra de cálculo da compatibilidade

Cada item da vistoria recebe uma pontuação de acordo com seu status:

| Status | Pontos |
|---|---:|
| Bom | 10 |
| Regular | 5 |
| Ruim | 0 |

O percentual de aprovação é calculado através da seguinte fórmula:

    Percentual = (Pontos obtidos × 100) / Pontos máximos

### Classificação

- 90% ou mais: Aprovado com Excelência
- 60% até 89,99%: Aprovado com Apontamentos
- Abaixo de 60%: Reprovado

Essa regra foi escolhida porque permite transformar os resultados individuais da vistoria em uma porcentagem simples de interpretar.

---

## Critério de priorização das habilidades

As recomendações de manutenção são organizadas de acordo com a gravidade do problema encontrado.

### Itens Ruins

Recebem prioridade máxima e são apresentados como:

    ITENS CRÍTICOS / REPROVADOS

### Itens Regulares

Recebem prioridade preventiva e são apresentados como:

    ITENS DE ATENÇÃO

### Itens Bons

Não recebem recomendações de manutenção.

Dessa forma, os problemas mais graves aparecem primeiro e recebem maior atenção.

---

## Conceitos do Módulo 01 aplicados

### Classes e Objetos

O projeto utiliza classes para representar os principais elementos do sistema:

- Veiculo
- Carro
- Moto
- Caminhao
- ItemVIstoria
- Vistoria
- Cadastro
- Relatorio

### Encapsulamento

O encapsulamento foi utilizado para controlar o acesso às propriedades.

Exemplo:

    public string Status { get; private set; }

Nesse caso, o Status pode ser consultado externamente, mas sua alteração é controlada pela própria classe.

### Herança

As classes Carro, Moto e Caminhao herdam da classe Veiculo.

Exemplo:

    public class Carro : Veiculo

Isso permite reutilizar os atributos e comportamentos comuns dos veículos.

### Abstração

A classe Veiculo foi definida como abstrata:

    public abstract class Veiculo

Ela representa as características comuns dos veículos e serve como classe base para as classes filhas.

### Polimorfismo

Os diferentes tipos de veículos podem ser armazenados em uma mesma lista:

    List<Veiculo> veiculosVistoriados

Essa lista pode armazenar objetos do tipo Carro, Moto e Caminhao.

### Override

Os veículos podem sobrescrever métodos da classe base para possuir comportamentos específicos.

Exemplo:

    public override List<string> ObterChecklistObrigatorio()

Assim, cada tipo de veículo pode possuir seu próprio checklist de vistoria.

---

## Arquitetura Cliente-Servidor

Arquitetura cliente-servidor é um modelo em que uma aplicação cliente envia solicitações para um servidor, que processa essas solicitações e retorna os resultados.

Neste projeto, a arquitetura cliente-servidor ainda não foi implementada.

O AutoCheck.NET atualmente funciona como uma aplicação Console local. Os dados são armazenados durante a execução do programa e não existe comunicação com um servidor ou banco de dados remoto.

Uma possível evolução do projeto seria utilizar uma API para separar o cliente do servidor:

    Cliente
       |
       v
    API / Servidor
       |
       v
    Banco de Dados

Dessa forma, o cliente poderia enviar os dados das vistorias para o servidor, que seria responsável pelo processamento e armazenamento.

---

## Vídeo de apresentação

O vídeo apresenta o funcionamento do sistema, sua execução, organização do projeto e os principais conceitos utilizados.

Link do vídeo:

[LINK_DO_VIDEO](https://drive.google.com/file/d/19QP4JNFGXPjM1WGVoZK8Sjqn05YLAC0t/view?usp=sharing)

---

## Autor
Bruno Bahy.
Projeto desenvolvido para fins acadêmicos, com foco no aprendizado de C#, .NET e Programação Orientada a Objetos.
