import style from "../athlete-marketplace/marketplace-result-item.module.css";
import {Rating, Typography} from "@mui/material";

const MarketplaceResultItem = () => {

    return(
        <div className={style.container}>
            <div className={style.photo}>
            </div>
            <div className={style.info}>
                <h5 style={{color:"#3538CD"}}>You are in the right hands!</h5>
                <h5>Entry-level full body 4 weeks</h5>
                <div className={style.rating}>
                    <Typography component="legend"></Typography>
                    <Rating
                        name="simple-controlled"
                        value={5}
                        // onChange={(event, newValue) => {
                        //     setValue(newValue);
                        // }}
                    /><p>202 reviews</p>
                </div>
                <div>
                    <div className={style.icon}></div>
                    <p>Polish</p>
                </div>
            </div>
            <div className={style.price}>
                <p>120 PLN total</p>
            </div>
        </div>
    );
}

export default MarketplaceResultItem;