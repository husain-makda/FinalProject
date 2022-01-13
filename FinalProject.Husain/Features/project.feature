Feature: WebsiteTest

Be able to login to the website, add an item to cart, apply discount and be able to place order. 
Background: 
Given I am on the login page

@tag1
Scenario: Able to place order
	When using a valid username 'hello@gmail.com' and password 'Password25@//200'
	And I add item to cart, which I view
	When I apply disocunt code
	Then Correct disocunt is applied
	Then Place order and view order number

	
	
	
	
	
	
	


