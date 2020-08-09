import * as mongoose from "mongoose";
import { app } from "./app";

const startApp = async () => {
  // check for env variables
  checkEnvironment("MONGO_URI", "PORT");

  try {
    await mongoose.connect(process.env.MONGO_URI, {
      useNewUrlParser: true,
      useUnifiedTopology: true,
    });
  } catch (error) {
    console.error(error);
  }

  const port = process.env.PORT;
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
