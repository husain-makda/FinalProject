Feature: WebsiteTest

Be able to login to the website, add an item to cart, apply discount and be able to place order. 

@tag1
Scenario: Able to place order
	Given I am on the login page, using a valid username and password
	When I add a cap to cart which I view
	Then Correct disocunt is applied
	Then I am able to checkout
	Then I can place order
	
	
	
	
	
	
	


