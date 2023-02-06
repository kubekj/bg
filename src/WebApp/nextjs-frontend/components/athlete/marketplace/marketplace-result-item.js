import style from "../marketplace/marketplace-result-item.module.css";
import { Rating, Typography } from "@mui/material";

const MarketplaceResultItem = ({plan}) => {
  return (
    <div className={style.container}>
      <div className={style.photo} />
      <div className={style.info}>
        <h5 style={{ color: "#3538CD", marginBottom: "1rem" }}>
          You are in the right hands!
        </h5>
        <h4>{plan.title}</h4>
        <div className={style.rating}>
          <Rating
            name='simple-controlled'
            value={plan.ratingAvg}
            disabled={true}
          />
          <p style={{ margin: "0" }}>202 reviews</p>
        </div>
        <div style={{ display: "flex", marginTop: "1rem" }}>
          <div className={style.icon} />
          <p>Polish</p>
        </div>
      </div>
      <div className={style.price}>
        <p style={{ margin: "0" }}>{plan.price} $</p>
      </div>
    </div>
  );
};

export default MarketplaceResultItem;
