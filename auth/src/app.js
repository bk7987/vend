"use strict";
exports.__esModule = true;
exports.app = void 0;
var express = require("express");
require("express-async-errors");
var body_parser_1 = require("body-parser");
var app = express();
exports.app = app;
app.use(body_parser_1.json);
