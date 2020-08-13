import mongoose from "mongoose";
import firebase from "firebase-admin";
import { app } from "./app";
import { natsClient } from "./nats-client";

const startApp = async () => {
  checkEnvironment("MONGO_URI", "PORT", "FIREBASE_CONFIG", "NATS_CLUSTER_ID", "NATS_CLIENT_ID", "NATS_URL");
  await connectDb();
  initializeFirebase();
  await connectNats();

  const port = process.env.PORT || 3000;
  app.listen(port, () => {
    console.log(`User service listening on port ${port}.`);
  });
};

const checkEnvironment = (...args: string[]) => {
  args.forEach((arg) => {
    if (!process.env[arg]) {
      throw new Error(`${arg} is not defined.`);
    }
  });
};

const connectDb = async () => {
  try {
    await mongoose.connect(process.env.MONGO_URI!, {
      useNewUrlParser: true,
      useUnifiedTopology: true,
      useCreateIndex: true,
    });
    console.log("User service connected to MongoDB.");
  } catch (error) {
    console.error(error);
  }
};

const initializeFirebase = () => {
  try {
    firebase.initializeApp();
    console.log("User service Firebase authentication initialized.");
  } catch (error) {
    console.error(error);
  }
};

const connectNats = async () => {
  try {
    await natsClient.connect(process.env.NATS_CLUSTER_ID!, process.env.NATS_CLIENT_ID!, process.env.NATS_URL!);
    natsClient.client.on("close", () => {
      console.log("NATS connection closed");
      process.exit();
    });
    process.on("SIGINT", () => natsClient.client.close());
    process.on("SIGTERM", () => natsClient.client.close());
  } catch (error) {
    console.error(error);
  }
};

startApp();
