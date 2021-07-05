To initialize the Web Api, re-build the project and then run it. The server will be initiated on port 5001 (localhost:5001).

The business logic is based on the ascii codes of mathematical operands (i.e +, -, *, /); it sends an array of the numerical representations of these operands to the client.
The client is responsible for converting those numerical values back to their string representations.
The API receives a request with said ascii code, and will then find the corresponding operation (IOperation) by that code and execute the operation and return its result.

I'm also using the Strategy Pattern to decide which operation is required for the request, so to add a new operation (for example, sin/con/pow) without changing existing code, all we have to do is add a new IOperation instance to the constructor of the Calculator class (BusinessLogic/Calculator.cs).

If you'd like to explore the API just add /swagger to the url once the server is up and running.

(Developed with Visual Studio Code and .NET Core 5.0)
