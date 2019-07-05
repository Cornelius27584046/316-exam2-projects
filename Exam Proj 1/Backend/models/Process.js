import mongoose from 'mongoose';

const Schema = mongoose.Schema;

let Process = new Schema({
  name: {
    type: String
  },
  ArrivalTime: {
    type: String
  },
  BurstTime: {
    type: String
  },
  TurnaroundTime: {
    type: String
  },
  WaitTime: {
    type: String
  },
  ReactTime: {
    type: String
  }
});

module.exports = mongoose.model('Process', Process);
