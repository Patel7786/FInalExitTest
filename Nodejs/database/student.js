const express =require('express');
const router=express.Router();
const con =require('./db.js');
const { request } = require('http');
const path=require('path');
const { builtinModules, Module } = require('module');
router.get("/student",(request,response)=>
{
    response.render(path.join(__dirname,("../View/student.ejs")));
});

Module.exports=router;