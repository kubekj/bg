import style from "../marketplace/marketplace-main-view.module.css";
import MarketplaceResultItem from "./marketplace-result-item";
import Link from "next/link";
import { Pagination } from "@mui/material";
import Button from "../../reusable/button";
import React from "react";

const MarketplaceMainView = ({ plans }) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h3>Marketplace</h3>
      </div>
      <div className={style.mid}>
        <div>
          <h2>{plans.length} trainings found</h2>
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
            {/*<button className='btn btn-outline-dark me-md-2' type='button'>*/}
            {/*  Cancel*/}
            {/*</button>*/}
            <Button
              text='Cancel'
              extraStyleType='border'
              extraStyleValue='1px solid #D0D5DD'
              backgroundColorValue='white'
              isHoveringColor='#D0D5DD'
            />
            {/*<button className='btn btn-primary' type='button'  style={{backgroundColor:"#8098F9"}}>*/}
            {/*  Search*/}
            {/*</button>*/}
            <Button
              iconSrc='/thumbnails/wsearch-outline.svg'
              text='Search'
              extraStyleType='border'
              extraStyleValue='1px solid #D0D5DD'
              backgroundColorValue='#8098F9'
              isHoveringColor='#C7D7FE'
              color='white'
            />
          </div>
        </div>
      </div>
      <div className={style.resultSection}>
        {plans.length === 0 && (
          <div className='flex flex-row items-center p-6 mx-auto'>
            Couldn't find any training plans at this moment, please try again
            later
          </div>
        )}
        {plans.map((plan) => {
          return (
            <Link
              href={{
                pathname: `/athlete/marketplace/plan`,
                query: { id: plan.id },
              }}
              style={{ textDecoration: "none" }}
              key={plan.id}
            >
              <MarketplaceResultItem plan={plan} />
            </Link>
          );
        })}
      </div>
      {plans.length > 0 && (
        <div className='flex flex-row items-center p-6 mx-auto'>
          <Pagination></Pagination>
        </div>
      )}
    </div>
  );
};

export default MarketplaceMainView;
