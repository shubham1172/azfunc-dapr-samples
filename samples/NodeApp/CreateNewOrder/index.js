module.exports = async function (context) {
    context.log("Node function processed a CreateNewOrder request from the Dapr Runtime.");
    context.log("Order data: " + JSON.stringify(context.bindings.payload));

    // save to state store
    context.bindings.saveOrder = {
        key: JSON.stringify(context.bindings.payload["orderId"]),
        value: context.bindings.payload
    };

    // publish event
    context.bindings.publishOrder = {
        payload: context.bindings.payload,
    };
};