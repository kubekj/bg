import style from "../styles/athlete-main-page.module.css";
import DefaultLeftPane from "../components/reusable-comps/default-left-pane";
import MarketplaceMainView from "../components/athlete-view/athlete-marketplace/marketplace-main-view";

const AthleteMarketplace = () => {

    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <MarketplaceMainView />
        </div>
    );
}

export default AthleteMarketplace;