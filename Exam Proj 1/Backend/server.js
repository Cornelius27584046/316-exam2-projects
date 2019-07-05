import express from 'express';
import cors from 'cors';
import bodyParser from 'body-parser';
import mongoose from 'mongoose';
const app = express();
app.use(cors());
app.use(function(req, res, next) {
  res.header('Access-Control-Allow-Origin', '*');
  res.header('Access-Control-Allow-Methods', 'GET, PUT, POST, DELETE');
  res.header('Access-Control-Allow-headers', 'Content-Type');
  next();
});

//Database
mongoose.connect('mongodb://127.0.0.1:27017/Processs', { useNewUrlParser: true })
  .then(() => console.log('Connected to database')) //use a promise
  .catch(err => console.error(err));

  /*connection.once('open', () => {
    console.log('MongoDB database connection established successfully!');
  });*/

//Middleware
app.use(express.urlencoded({ extended: true })); //allows us to use form. for example creating user from a form
//app.use(express.json()); //allows us to use json
app.use(bodyParser.json());

//Controllers
const ProcessControl = require('./controllers/ProcessControl');

//Router
app.post('/api/process/create', ProcessControl.create);
app.post('/api/process/update', ProcessControl.update);
app.get('/api/process/get', ProcessControl.retrieve);

//Start Server
app.listen(3000, () => console.log('Server has started at port 3000'));
