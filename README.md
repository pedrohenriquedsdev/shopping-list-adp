# 🛒 Lista de Compras

> *"Nunca mais esqueça o leite!"* — Um sistema completo para organizar as compras da família com praticidade e inteligência.

---

## 📖 Sobre o Projeto

**Lista de Compras** nasceu de uma necessidade real: Maria fazia as compras da família toda semana, mas vivia esquecendo itens ou comprando produtos que já tinha em casa. Para resolver esse problema do dia a dia, foi criado um sistema simples, intuitivo e eficiente para cadastrar produtos, organizar listas e registrar compras realizadas.

Este projeto foi desenvolvido pelos alunos da **Academia do Programador** como solução prática para um problema cotidiano.

---

## ✨ Funcionalidades

O sistema é dividido em **4 módulos principais**:

### 🏷️ Módulo de Categorias
Organize seus produtos em categorias coloridas e intuitivas.

| Funcionalidade | Descrição |
|---|---|
| ➕ Cadastrar | Crie novas categorias com nome e cor personalizados |
| ✏️ Editar | Atualize o nome ou a cor de uma categoria existente |
| 🗑️ Excluir | Remova categorias que não são mais necessárias |
| 📋 Visualizar | Consulte todas as categorias cadastradas |

**Regras:**
- Nome único, com no máximo 50 caracteres
- Cor obrigatória (paleta de cores ou código hexadecimal)
- Não é possível excluir uma categoria que possua produtos vinculados

---

### 📦 Módulo de Produtos
Seu catálogo completo de produtos, sempre à mão.

| Funcionalidade | Descrição |
|---|---|
| ➕ Cadastrar | Adicione produtos com categoria, unidade e preço estimado |
| ✏️ Editar | Atualize as informações de qualquer produto |
| 🗑️ Excluir | Remova produtos do catálogo |
| 📋 Visualizar | Consulte todos os produtos cadastrados |

**Regras:**
- Nome obrigatório (entre 2 e 100 caracteres)
- Categoria, unidade de medida e preço aproximado são obrigatórios
- Não é permitido cadastrar produtos com o mesmo nome na mesma categoria

---

### 📝 Módulo de Listas de Compras
Crie e gerencie suas listas de compras de forma organizada.

| Funcionalidade | Descrição |
|---|---|
| ➕ Criar | Monte uma nova lista com nome personalizado |
| ✏️ Editar | Atualize o nome ou o status de uma lista |
| 🗑️ Excluir | Remova listas que não são mais necessárias |
| 📋 Visualizar | Acompanhe todas as suas listas e seus resumos |

**Regras:**
- Nome obrigatório (entre 3 e 100 caracteres)
- Data de criação gerada automaticamente pelo sistema
- Status da lista: `Aberta` ou `Concluída`
- Não é possível excluir uma lista que já tenha itens vinculados
- O sistema exibe o **total de itens** e o **total estimado** de cada lista

---

### 🧺 Módulo de Itens da Lista
Adicione produtos às suas listas e acompanhe tudo em tempo real.

| Funcionalidade | Descrição |
|---|---|
| ➕ Adicionar | Inclua produtos com quantidade desejada |
| 🗑️ Remover | Retire itens da lista quando necessário |
| 📋 Visualizar | Veja todos os itens de uma lista, com categoria e preço |

**Regras:**
- Produto e quantidade (número positivo) são obrigatórios
- O mesmo produto não pode ser adicionado duas vezes na mesma lista
- O **valor total é calculado automaticamente**: `Σ (preço estimado × quantidade)`

---

## 🗂️ Estrutura dos Módulos

```
lista-de-compras/
│
├── 📁 categorias/        → Gerenciamento de categorias
├── 📁 produtos/          → Catálogo de produtos
├── 📁 listas/            → Listas de compras
└── 📁 itens/             → Itens vinculados às listas
```

---

## 🔒 Regras de Negócio — Resumo Rápido

| Regra | Módulo |
|---|---|
| Nomes de categorias únicos (máx. 50 chars) | Categorias |
| Cor obrigatória para cada categoria | Categorias |
| Não excluir categoria com produtos vinculados | Categorias |
| Nome do produto: 2–100 chars, único por categoria | Produtos |
| Categoria, unidade e preço são obrigatórios | Produtos |
| Nome da lista: 3–100 chars | Listas |
| Status: Aberta ou Concluída | Listas |
| Não excluir lista com itens vinculados | Listas |
| Exibir total de itens e total estimado por lista | Listas |
| Quantidade deve ser número positivo | Itens |
| Produto único por lista | Itens |
| Total calculado automaticamente | Itens |

---

## 👩‍💼 Contexto do Projeto

> **Maria** faz as compras da família toda semana, mas sempre esquecia algum item ou comprava coisas que já tinha em casa. Por isso, resolveu pedir ajuda para organizar melhor as compras. Assim nasceu o projeto **Lista de Compras** — desenvolvido pelos alunos da **Academia do Programador**.

---

## 🚀 Como Começar

1. **Cadastre as categorias** — organize seus produtos (ex: Laticínios 🥛, Hortifruti 🥦, Bebidas 🧃)
2. **Cadastre os produtos** — adicione ao catálogo com unidade e preço estimado
3. **Crie uma lista** — dê um nome e comece a planejar suas compras
4. **Adicione os itens** — selecione os produtos e as quantidades desejadas
5. **Conclua a lista** — marque como "Concluída" ao finalizar as compras

---

## 🎓 Academia do Programador

Projeto desenvolvido como atividade prática pelos alunos da Academia do Programador.

---

*Feito com 💚 para facilitar o dia a dia de Maria — e de todos nós.*
