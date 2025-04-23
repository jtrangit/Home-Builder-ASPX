# Dream Home Builder 🏡

Dream Home Builder is a web-based application that allows users to customize a home purchase by selecting a home plan, roofing style, countertop type, and optional additions. After selections are made, the site generates a detailed receipt showing all costs and saves the transaction.

---

## 🚀 Features

- Collects user information via session variables
- Dynamically calculates the total cost of a customized home
- Supports various home plans, roofing options, countertops, and home additions
- Displays a breakdown of selected options and prices in a `GridView`
- Updates a backend database with total sale and home plan via `UpdateHomeSales()`

---

## 🛠 Technologies Used

- **ASP.NET Web Forms (C#)**
- **ADO.NET** (via `Utilities.DBConnect`)
- **SQL Server** (assumed for backend database)
- **Session Management** to carry user data across pages
- **HTML/CSS** for frontend (assumed from context)
- **GridView Control** for receipt presentation

---

## 📂 Code Structure

- `Results.aspx.cs` – Main code-behind file that:
- Retrieves session data
- Performs pricing calculations
- Binds data to a `GridView`
- Updates the home sales record

---

## 💾 Session Variables

The following session variables are expected to be set on previous pages:

- `bName` – Buyer’s name
- `bEmail` – Email address
- `bAddress` – Mailing address
- `bPhone` – Phone number
- `bEmployment` – Employment status
- `bIncome` – Income
- `bMoveIn` – Preferred move-in date
- `Homeplan` – Selected home plan
- `Roofing` – Selected roofing option
- `CountertopPrice` – Selected countertop
- `HomeAdditions` – ArrayList of additional features

---

## 💰 Pricing Dictionaries

Defined in the code for:

- `homePrices`
- `roofingPrices`
- `countertopPrices`
- `additionPrices`

These store item names and associated costs for calculations.

---

## 🧾 Receipt Generation

Data from selections is formatted into a `DataTable`, including:

- Home Plan
- Roofing
- Countertop
- Additions (each as a separate row)
- Final **Total** row

The table is bound to `gvReceipt` for user display.

---

## 🧮 Total Cost Logic

Total is calculated as the **sum** of:

- Base home plan price
- Selected roofing
- Selected countertop
- All selected additions

---

## 🛡 Notes

- Ensure session variables are set prior to page load.
- `DBConnect.UpdateHomeSales(decimal total, string homePlan)` must be implemented in your `Utilities` namespace for DB persistence.
- `counterPrice` is used for both roofing and countertop matching. Confirm naming for accuracy.
- Escaped characters like `&#39;` are replaced (e.g., `Slasher&#39;s Paradise` → `Slasher's Paradise`).

---

### Live Project Link: https://cis-iis2.temple.edu/Spring2024/CIS3342_tun45633/Project2/HomeBuilder.aspx

---

Johnny Tran <br>
267-423-6148 <br>
johnnytran.work@gmail.com
