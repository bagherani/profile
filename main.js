var MongoClient = require('mongodb').MongoClient;
var url = "mongodb://localhost:27017/profile_ir";

MongoClient.connect(url, function (err, db) {
    if (err) throw err;
    console.log("Database created!");

    var dbo = db.db("profile_ir");
    dbo.createCollection("users", function (err, res) {
        if (err) throw err;
        console.log("Collection created!");

        dbo.collection("customers").insertOne({id:1,value:''}, function (err, res) {
            if (err) throw err;
            console.log("1 document inserted");
            // db.close();
        });

    });
});

var http = require('http');

http.createServer(function (req, res) {
    console.log(req.body);
    res.writeHead(200, { 'Content-Type': 'text/html' });
    res.end('Hello World!');
}).listen(8080);