`use strict`;

const ANCHOR = document.getElementById("orderList");

const GET_ORDER_DATA = document.getElementById("actionButton");

LoadOrderList().then(orders => {
  for(const order of orders) {
    ANCHOR.appendChild(new Option(`Order ID: ${order.id}`,`${order.id}`));
  }
  return;
});

GET_ORDER_DATA.addEventListener("click", () => {
  const whichOrderID = document.getElementById("orderList").value;
  // HeyYouGuys(whichOrderID); 

  DisplayOrderDetails(whichOrderID);
});

function DisplayOrderDetails(orderID) {
  const TABLE_AREA = document.getElementById("orderDetails");
  TABLE_AREA.innerHTML = ``;
  return fetch(`/api/order/${orderID}`).then(response =>{
    if(!response.ok)
    {
      TABLE_AREA.innerHTML = `<h3> Network response was not ok </h3>`;
      throw new Error(`Network response was not ok status: (${response.status})`);
    }
    return response.json();
  }).then(orderInfo =>{
    if(orderInfo.length === 0)
    {
      TABLE_AREA.innerHTML = `ORDER ERROR 500:
      ORDERED ITEMS CAN'T BE FOUND`;
      return;
    } else {
      TABLE_AREA.innerHTML = ``;
      
      // TABLE_AREA.innerHTML = `${orderInfo}`;
      TABLE_AREA.innerHTML = `<p id="addOrderLinesHere">Customer ID: ${orderInfo.customerId} Location ID: ${orderInfo.locationId} Order Time: ${orderInfo.timeOfOrder.substring(0, 10)}</p>`;
      if(orderInfo.orderItems.length === 0) {
        let noItems = document.createElement("p");
        noItems.innerHTML = `No Items Ordered`;
        document.getElementById("addOrderLinesHere").appendChild(noItems);
      } else {
        orderInfo.orderItems.forEach(orderedItem => {
          let orderedItemInfo = document.createElement("p");
          orderedItemInfo.innerHTML = `Prodcuct Id: ${orderedItem.productId} Quantity: ${orderedItem.quantity}`
          document.getElementById("addOrderLinesHere").appendChild(orderedItemInfo);
        });
      }
    }
  })

}