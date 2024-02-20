Feature: OrderPlacement

Successfull order placements from Sauce Demo application

Scenario Outline: Validate successful order placement for single item by the user from Sauce Demo application
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
	And The user views Products page
	When The user clicks on Add to cart button with <ItemToOrder> product from Prodcuts page
	Then The user views 1 items in the cart
	When The user clicks on the cart icon
	Then The user views Your Cart page
	When The user clicks Checkout button from Your Cart page
	Then The user views Checkout Your Information page
	When The user enters First Name as <FirstName>, Last Name as <LastName>, Postal Code as <PostalCode> on Checkout Your Information page
	And The user clicks on Continue button on Your Cart page
	Then The user views Checkout Overivew page
	And The user verifies products on the Checkout Overivew page
	And The user verifies Payment Information on the Checkout Overivew page
	And The user verifies Shipping Information on the Checkout Overivew page
	And The user verifies Price Total Information on the Checkout Overivew page
	When The user clicks on Finish button
	Then The user view Checkout Complete page
	And The user verifies Succuess message
	When The user clicks on Back Home button on Checkout Complete page
	Then The user views Products page
	And The user verifies zero items in the cart
	When The user clciks on Logout from menu options
	Then The user views Sauce Demo login page

Examples: 
	| Username                | Password     | ItemToOrder                       | FirstName | LastName | PostalCode |
	| standard_user           | secret_sauce | Sauce Labs Backpack               | TestFN    | TestLN   | A1A B2B    |
	| performance_glitch_user | secret_sauce | Sauce Labs Bike Light             | TestFN    | TestLN   | A1A B2B    |
	| standard_user           | secret_sauce | Sauce Labs Bolt T-Shirt           | TestFN    | TestLN   | A1A B2B    |
	| performance_glitch_user | secret_sauce | Sauce Labs Fleece Jacket          | TestFN    | TestLN   | A1A B2B    |
	| standard_user           | secret_sauce | Sauce Labs Onesie                 | TestFN    | TestLN   | A1A B2B    |
	| performance_glitch_user | secret_sauce | Test.allTheThings() T-Shirt (Red) | TestFN    | TestLN   | A1A B2B    |


Scenario Outline: Validate successful order placement for multiple products by the user from Sauce Demo application
	Given The user is on the Login page
	When The user enters Username as <Username> and Password as <Password>
	Then The user clicks on Login button
	And The user views Products page
	When The user clicks on Add to cart button with <ItemToOrder1> product from Prodcuts page
	Then The user views 1 items in the cart
	When The user clicks on <ItemToOrder2> product image from Products page
	Then The user verifies <ItemToOrder2> details on Product page
	When The user clicks on Add to cart button with <ItemToOrder2> product from Large Prodcut page
	Then The user views 2 items in the cart
	When The user clicks on the cart icon
	Then The user views Your Cart page
	When The user clicks Checkout button from Your Cart page
	Then The user views Checkout Your Information page
	When The user enters First Name as <FirstName>, Last Name as <LastName>, Postal Code as <PostalCode> on Checkout Your Information page
	And The user clicks on Continue button on Your Cart page
	Then The user views Checkout Overivew page
	And The user verifies products on the Checkout Overivew page
	And The user verifies Payment Information on the Checkout Overivew page
	And The user verifies Shipping Information on the Checkout Overivew page
	And The user verifies Price Total Information on the Checkout Overivew page
	When The user clicks on Finish button
	Then The user view Checkout Complete page
	And The user verifies Succuess message
	When The user clicks on Back Home button on Checkout Complete page
	Then The user views Products page
	And The user verifies zero items in the cart
	When The user clciks on Logout from menu options
	Then The user views Sauce Demo login page

Examples: 
	| Username      | Password     | ItemToOrder1        | ItemToOrder2          |FirstName | LastName | PostalCode |
	| standard_user | secret_sauce | Sauce Labs Backpack | Sauce Labs Bike Light |TestFN    | TestLN   | A1A B2B    |
