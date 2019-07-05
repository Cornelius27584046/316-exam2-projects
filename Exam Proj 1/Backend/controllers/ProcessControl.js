const Process = require('../models/Process');

module.exports = {
  create: (req, res) => { //INSERT
    let process = new Process({
      title: req.body.title,
      responsible: req.body.responsible,
      description: req.body.description,
      severity: req.body.severity,
      status: req.body.status
    });

    process.save() //save in db
      .then(result => {
        res.json(result);
      })
      .catch(err => {
        res.json(err);
      });
  },
  update: (req, res) => { //UPDATE
    Process.updateOne({ _id: req.body._id }, req.body)
      .then(process => {
        if(!process) res.json({ result: "Process does not exist!" });

        res.json(process);
      })
      .catch(err => {
        res.json(err);
      });
  },
  retrieve: (req, res) => { //SELECT *
    Process.find()
      .then(result => {
        if(!result) res.json({ result: "No results found."});

        res.json(result)
      })
      .catch(err => res.json(err))
  }
}
