const express =require('express');
const router=express.Router();
const con =require('./db.js');
const { request } = require('http');
const path=require('path');


router.get('/teacher',(req,resp)=>{
    con.query('select * from addrecord',(err,result)=>
    {
        if(err) throw err;
        var d=JSON.parse(JSON.stringify(result));
        console.log(d);
      
        resp.render(path.join(__dirname,("../View/profile.ejs")), { data: d });
    });
})

module.exports = router;

