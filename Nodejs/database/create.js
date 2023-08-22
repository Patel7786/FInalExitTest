
const express =require('express');
const router=express.Router();
const con =require('./db.js');
const { request } = require('http');
const path=require('path');
router.post('/create', function(req, res)
{
   console.log(req.body);
   var {rollNo,name,dateofBirth,score}=req.body;
   
    con.query('insert into addrecord values(?,?,?,?)',[rollNo,name,score,req.body.dateOfBirth],(err,result)=>{
        if(err) throw err;
        console.log("Record Inserted")});
        res.sendFile(path.join(__dirname,("../View/home.html")));
   
});