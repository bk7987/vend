import * as mongoose from "mongoose";
import * as firebase from "firebase-admin";
import { app } from "./app";

const startApp = async () => {
  checkEnvironment("MONGO_URI", "PORT", "FIREBASE_CONFIG");

  try {
    await mongoose.connect(process.env.MONGO_URI, {
      useNewUrlParser: true,
      useUnifiedTopology: true,
      useCreateIndex: true,
    });
    console.log("Auth service connected to MongoDB.");
  } catch (error) {
    console.error(error);
  }

  try {
    firebase.initializeApp();
    console.log("Auth service Firebase authentication initialized.");
  } catch (error) {
    console.error(error);
  }

  const port = process.env.PORT || 3000;
  app.listen(port, () => {
    console.log(`Auth service listening on port ${port}.`);
  });
};

const checkEnvironment = (...args: string[]) => {
  args.forEach((arg) => {
    if (!process.env[arg]) {
      throw new Error(`${arg} is not defined.`);
    }
  });
};

startApp();
