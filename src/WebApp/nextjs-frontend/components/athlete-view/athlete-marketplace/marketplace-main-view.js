import style from "../athlete-marketplace/marketplace-main-view.module.css";
import MarketplaceResultItem from "./marketplace-result-item";
import Link from "next/link";
import { Pagination } from "@mui/material";

const MarketplaceMainView = () => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h3>Marketplace</h3>
      </div>
      <div className={style.mid}>
        <div>
          <h2>232 trainings found</h2>
          <p>Click on the training plan you'd like to check out</p>
        </div>
        <div className={style.search}>
          <form className='d-flex' role='search'>
            <input
              className='form-control me-2'
              type='search'
              placeholder='Search'
              aria-label='Search...'
            />
          </form>
          <div className='d-grid gap-2 d-md-flex justify-content-md-end'>
            <button className='btn btn-outline-dark me-md-2' type='button'>
              Cancel
            </button>
            <button className='btn btn-primary' type='button'>
              Search
            </button>
          </div>
        </div>
      </div>
      <div className={style.resultSection}>
        <Link href='/athlete-buy-training'>
          <MarketplaceResultItem />
        </Link>
        <MarketplaceResultItem />
        <MarketplaceResultItem />
        <MarketplaceResultItem />
      </div>
      <div className='flex flex-row items-center p-6 mx-auto'>
        <Pagination></Pagination>
      </div>
    </div>
  );
};

export default MarketplaceMainView;
