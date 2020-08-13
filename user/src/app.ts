import express from "express";
import "express-async-errors";
import { json } from "body-parser";
import { UserCreatedPublisher } from "./events/publishers";
import { natsClient } from "./nats-client";

const app = express();
app.set("trust proxy", true);
app.use(json());

app.all("*", async (_req: express.Request, res: express.Response) => {
  const userPublisher = new UserCreatedPublisher(natsClient.client);
  userPublisher.publish({ id: "new user!", email: "this is the email", displayName: "Bill Kerr", version: 1 });
  res.send({ message: "hello from users!" });
});

export { app };
