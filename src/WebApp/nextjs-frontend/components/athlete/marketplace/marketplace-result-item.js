import style from "../marketplace/marketplace-result-item.module.css";
import { Rating, Typography } from "@mui/material";

const MarketplaceResultItem = () => {
  return (
    <div className={style.container}>
      <div className={style.photo} />
      <div className={style.info}>
        <h5 style={{ color: "#3538CD", marginBottom: "1rem" }}>
          You are in the right hands!
        </h5>
        <h5>Entry-level full body 4 weeks</h5>
        <div className={style.rating}>
          {/*<Typography component="legend"></Typography>*/}
          <Rating
            name='simple-controlled'
            value={5}
            // onChange={(event, newValue) => {
            //     setValue(newValue);
            // }}
          />
          <p style={{ margin: "0" }}>202 reviews</p>
        </div>
        <div style={{ display: "flex", marginTop: "1rem" }}>
          <div className={style.icon} />
          <p>Polish</p>
        </div>
      </div>
      <div className={style.price}>
        <p style={{ margin: "0" }}>120 PLN total</p>
      </div>
    </div>
  );
};

export default MarketplaceResultItem;
