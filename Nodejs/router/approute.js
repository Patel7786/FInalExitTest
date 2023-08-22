
const { query } = require('express');
const express =require('express');
const { request } = require('http');
const path=require('path');
var app=express();

const port=process.env.Port || 9090;
//for checking the current directory and fiels
//console.log(__dirname);
//console.log(path.join(__dirname,('../View/home.html')));

var bodyParser = require('body-parser');
var multer = require('multer');
var upload = multer();
app.set('view engine', 'ejs');
app.set('views', './Views');

var teacherRouter=require('../database/teacher.js');


// for parsing application/json
app.use(bodyParser.json()); 

// for parsing application/xwww-
app.use(bodyParser.urlencoded({ extended: true })); 
//form-urlencoded
// for parsing multipart/form-data
app.use(upload.array());    
app.use(express.static('public'));
app.get('/teacher',teacherRouter);


const con =require('../database/db.js');




app.post('/create', function(req, res)
{
   console.log(req.body);
   var {rollNo,name,dateofBirth,score}=req.body;
   
    con.query('insert into addrecord values(?,?,?,?)',[rollNo,name,score,req.body.dateOfBirth],(err,result)=>{
        if(err) throw err;
        console.log("Record Inserted")});
        res.sendFile(path.join(__dirname,("../View/home.html")));
   
});

app.post('/search',(req,res)=>{
    //console.log(req.body);
    con.query('select * from addrecord where RollNumber=? and Name=?',[req.body.rollNo,req.body.name],(err,result)=>{
        if(err) throw err;
        res.render(path.join(__dirname,("../View/showresult.ejs")), { data: result });
    });
});

app.post('/edit',async (req,res)=>{
    con.query('Update addrecord set Name=?,Score=?,DOB=? where RollNumber=?',[req.body.name,req.body.score,req.body.dateOfBirth,req.body.rollNo],(err,result)=>{
        if(err) throw err;
        console.log(req.body);
        console.log("Update the Record");
        res.sendFile(staticPath);
    })
})


app.get('/delete/:rollNo',(req,res)=>{
    console.log("----------------------------Deletion tab--------------------------");
    const RollNumber = req.params.rollNo;
    con.query('delete from addrecord where RollNumber=?',[RollNumber],(err,result)=>{
        if(err) throw err;
        res.sendFile(staticPath);
    })
})
app.get('/edit/:rollNo',(req,res)=>{
    console.log("-----------------------this is Edit tab--------------------------");
    const RollNumber = req.params.rollNo;
    
    console.log(RollNumber);
    con.query('select * from addrecord where RollNumber=?',[RollNumber],(err,result)=>{
        if(err) throw err;
        //console.log(result);
        var d=JSON.parse(JSON.stringify(result));
        console.log(d);
        res.render(path.join(__dirname,("../View/edit.ejs")), { data: d });
    });
});

const staticPath=path.join(__dirname,("../View/home.html"));
app.use(express.static(staticPath));

app.get("/",(request,response)=>
{
    response.sendFile(staticPath);
});

/*
app.get("/teacher",(request,response)=>
{

    
    var d=f.findAll();
    console.log(d);
    response.render(path.join(__dirname,("../View/profile.ejs")), { data: d });
});*/

app.get("/addrecord",(request,response)=>
{
    response.sendFile(path.join(__dirname,("../View/addrecord.html")));
});


app.get("/student",(request,response)=>
{
    response.render(path.join(__dirname,("../View/student.ejs")));
});

app.get("/logout",(request,response)=>
{
    response.sendFile(staticPath);
});
app.get("/error",(request,responce)=>{
    responce.send("<h1> 404 Error</h1>");
})
app.listen(port);

