import * as express from "express";
import "express-async-errors";
import { json } from "body-parser";

const app = express();
app.set("trust proxy", true);
app.use(json());

app.all("*", async (_req: express.Request, res: express.Response) => {
  res.send({ message: "hello from users!" });
});

export { app };
