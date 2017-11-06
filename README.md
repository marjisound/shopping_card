# shopping_card
A simple online shopping system - ASP.NET MVC

I worked on this “Shopping Kart Test” project using ASP.Net MVC with “.NET Framework 4.6.1”. 

It consists of two pages as follows:
*	Home page: Displays all products along with their price and possible offers. User can click “add to card” button for each product. If more than one unit of a product is needed, the number can be specified using the number box. 
*	Checkout: Displays all the products that are in the shopping basket along with the total price after discount, discount and total price before discount. User can delete product from the basket using the delete button. 

This application needs to be enhanced for a fully functional checkout system. For instance, user may also need to reduce or increase the quantity of the products in checkout section. Or admin should to be able to manage products and offers in the system. For this, the authentication should be added to the system. 

For this simple checkout system, I created three domain models in the database. The models were migrated to database using code first workflow: 
*	Products: Stores all existing product types existing in the shop. The fields are Name and Price.
*	Offers: Stores all existing offers for products. Fields are productId, Number and OfferedPrice. 
*	Baskets: Stores any product type that is added to the system by a specific user. Fields are ProductId, SessionId, Amount. ProductId and SessionId make the composite primary key. 

Two view model were created to make use of a combination of the domain models:
*	CheckoutDetail: The object that is used in the checkout view 
*	ProductOffersViewModel: The object that is used in the home view

Two controllers were created:
*	HomeController: Deals with the data that is sent to/from the Home view
*	CheckoutController: Deals with the data that is sent to/from the Checkout view



 
