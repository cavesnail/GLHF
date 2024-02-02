# GLHF

### Small demo fullstack webapp w/ C# ASP.NET & Angular

Set up for dev environment (publish deployment not configured), access via localhost:7075.
### API Endpoints:
All accessed via /api/purchase/
#### getAllPurchases
Returns all purchases, omitting Quantity, Unit Price, & Description, and adding Total Cost.
#### getPurchase
Returns a single purchase, requires passing an id parameter in url (e.g. /api/purchase/getPurchase?id=9), omits Id, adds Total Cost.
#### getTimeSeries
Returns a time series of spending per month.
#### getMostExpensiveMonth
Returns the month with the most money spent on purchases.
#### getMonthMostUnits
Returns the month with the most units bought.
#### getMostExpensivePurchaseProductName
Returns the product name pertaining to the most expensive purchase made.
#### getMostUnitsBoughtProductName
Returns the product name associated with the largest (in terms of quantity) purchase made.


### Notes
- No form of tiebreaking implemented for "most X" endpoints - nothing in specification, and explicitly states to return a single month/name. Would personally return array of ties.
- Only set up for dev environment - no configuration prepared for deployment, so if you try publishing without making any further changes, it won't work out of the box.