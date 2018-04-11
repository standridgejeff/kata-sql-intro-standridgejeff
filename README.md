# SqlIntro

C# introduction to SQL

## Kata Overview

Here's what you'll need to do for this Kata:

### Step 1

Clone this repo to your machine, then create a branch to accomplish your work (`git checkout -b your-branch-name`)

### Step 2

Navigate to the `ProductRepository.cs` and properly implement/complete all methods using raw SQL. When done, the `ProductRepository` class should be able to:

1. `SELECT` all products
1. `DELETE` a product with a particular `ProductId`
1. `UPDATE` a product's name with a particular `ProductId`
1. `INSERT` a new product

### Step 3

Add a class called `DapperProductRepository` and enable the same methods implemented in the `ProductRepository` class, but avoid raw SQL in favor of [Dapper](https://github.com/StackExchange/Dapper). Make sure you implement:

1. `SELECT` all products
1. `DELETE` a product with a particular `ProductId`
1. `UPDATE` a product's name with a particular `ProductId`
1. `INSERT` a new product

### Step 4

At this point, you have both `DapperProductRepository` and `ProductRepository` implementing the same methods. Make an Interface called `IProductRepository` that both your classes can conform to:

1. Add a method called `GetProductsWithReview` that performs an `INNER JOIN`
1. Add a method called `GetProductsAndReviews` that performs a `LEFT JOIN`

### Step 5

Push your changes (`git push`), create a pull request, and add request a review from your instructor.

**Good luck!**
