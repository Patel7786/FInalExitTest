
const mysql=require('mysql');
var connection=mysql.createConnection(
    {
        host:'localhost',
        user:'root',
        password:'password',
        database:'addstudent',

    });

    connection.connect((err) => {
        if (err) throw err;
        console.log('Connected!');
      });
    module.exports = connection;
