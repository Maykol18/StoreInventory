# 🏬 StoreInventory

## 📌 Descripción

**StoreInventory** es una API REST desarrollada con **ASP.NET Core Web API** que permite gestionar productos de un inventario, las categorías, los proveedores y las ventas mediante operaciones CRUD.

---

## 🚀 Tecnologías utilizadas

* C#
* ASP.NET Core Web API
* .NET
* LINQ
* Data Annotations
* Dependency Injection (DI)

---

## ⚙️ Instalación y ejecución

1. Clonar el repositorio:

```bash
git clone https://github.com/Maykol18/storeinventory.git
```

2. Acceder al proyecto:

```bash
cd storeinventory
```
3. Actualiza la base de datos
```bash
dotnet ef database update
```
3. Ejecutar la aplicación:

```bash
dotnet run
```

4. Abrir en el navegador:

```bash
https://localhost:5281/swagger
```

---

## 📦 Funcionalidades

* Obtener todos los productos, categorías, proveedores y órdenes
* Obtener producto, categoría, proveedor y orden por ID
* Crear nuevos productos, categorías, proveedores y órden
* Actualizar productos, categorías, proveedores y órdenes existentes
* Eliminar productos, categorías, proveedores y órdenes
* Validación de datos con DTOs

---

## 🔌 Endpoints de la API

### 📦 Productos

#### Obtener todos los productos

```
GET /api/product
```

#### Obtener producto por ID

```
GET /api/product/{id}
```

#### Crear producto

```
POST /api/product
```

Body:

```json
{
  "name": "Laptop",
  "price": 1200
}
```

#### Actualizar producto

```
PUT /api/product/{id}
```

#### Eliminar producto

```
DELETE /api/product/{id}
```

### 📦 categorías

#### Obtener todas las categorías

```
GET /api/category
```

#### Obtener categoría por ID

```
GET /api/category/{id}
```

#### Crear categoría

```
POST /api/category
```

Body:

```json
{
  "name": "Tecnologia"
}
```

#### Actualizar categoría

```
PUT /api/category/{id}
```

#### Eliminar categoría

```
DELETE /api/category/{id}
```

---

### 📦 Proveedores

#### Obtener todos los proveedores

```
GET /api/supplier
```

#### Obtener proveedor por ID

```
GET /api/supplier/{id}
```

#### Crear proveedor

```
POST /api/supplier
```

Body:

```json
{
  "name": "Amazon"
}
```

#### Actualizar proveedor

```
PUT /api/supplier/{id}
```

#### Eliminar proveedor

```
DELETE /api/supplier/{id}
```

### 📦 órdenes

#### Obtener todas las órdenes

```
GET /api/sale
```

#### Obtener orden por ID

```
GET /api/sale/{id}
```

#### Crear orden

```
POST /api/sale
```

Body:

```json
{
    "OrderItems": [
        {
            "id": 1,
            "quantity": 6
        },
        {
            "id": 2,
            "quantity": 6
        }
    ]
}
```

#### Actualizar orden

```
PUT /api/sale/{id}
```

#### Eliminar orden

```
DELETE /api/sale/{id}
```

### 📦 Reporte

#### Obtener el producto más vendido y la cantidad

```
GET /api/report/top-product
```

## 🧠 Conceptos aplicados

* Arquitectura basada en controladores
* Separación de responsabilidades
* Uso de DTOs para entrada de datos
* Validación con Data Annotations
* Manejo de respuestas HTTP (200, 201, 400, 404)
* Uso de colecciones en memoria como base de datos temporal

---

## 👨‍💻 Autor

German Michel
