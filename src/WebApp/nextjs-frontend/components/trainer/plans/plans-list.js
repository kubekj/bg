import style from "./plans-list.module.css";
import Link from "next/link";
import Button from "../../reusable/button";
import React from "react";
import { Chip, Pagination } from "@mui/material";
import { Stack } from "@mui/system";
import TrainingPlanModal from "../../athlete/modals/training-plan-modal";
import DeleteModal from "../../reusable/delete-modal";

const PlansList = (props) => {
  const { plans, workouts } = props;
  return (
    <>
      <div className={style.container}>
        <div className={style.header}>
          <h2>Training plans</h2>
          <p>Manage all your training plans here.</p>
        </div>
        <div className='relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-md rounded-xl'>
          <div className='rounded-t py-3 border-0'>
            <div className='flex flex-wrap items-center'>
              <div className='relative w-full px-4 max-w-full flex-grow flex-1'>
                <h3 className='font-semibold text-base text-blueGray-700 my-auto'>
                  Training plans
                </h3>
              </div>
              <div className='relative w-full px-4 max-w-full flex-grow flex-1 text-right'>
                <TrainingPlanModal
                  icon='/thumbnails/add-outline.svg'
                  text='Add new'
                  backgroundColorValue='#8098F9'
                  isHoveringColor='#C7D7FE'
                  extraStyleType='color'
                  extraStyleValue='white'
                  workouts={workouts}
                ></TrainingPlanModal>
              </div>
            </div>
          </div>
          <div className='block w-full overflow-x-auto'>
            <table className='items-center w-full bg-transparent border-collapse'>
              <thead className='thead-light bg-indigo-400 text-white'>
                <tr>
                  <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                    Title
                  </th>
                  <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                    Duration
                  </th>
                  <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                    No. of workouts
                  </th>
                  <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                    Language
                  </th>
                  <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                    Skill Level
                  </th>
                  <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                    Price
                  </th>
                  <th className='px-6 bg-blueGray-50 text-blueGray-500 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left min-w-140-px'></th>
                </tr>
              </thead>
              <tbody className='divide-y divide-gray-200'>
                {(plans && plans.length !== 0) ? plans.map((plan) => {
                  return (
                    <tr key={plan.id}>
                      <td className='text-xs p-4'>{plan.title}</td>
                      <td className='text-xs p-4'>{plan.duration}</td>
                      <td className='text-xs p-4'>{plan.noOfWorkouts}</td>
                      <td className='text-xs p-4'>{plan.language}</td>
                      <td className='text-xs p-4'>
                        {renderSkillLevel(plan.skillLevel)}
                      </td>
                      <td className='text-xs p-4'>{plan.price}</td>
                      <td className='border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 grid justify-items-end'>
                        <Stack
                          direction='row'
                          spacing={2}
                          className='items-center'
                        >
                          <TrainingPlanModal
                            icon='/thumbnails/copy-outline.svg'
                            backgroundColorValue='white'
                            isHoveringColor='#D0D5DD'
                            borderValue='none'
                            extraStyleType='color'
                            extraStyleValue='white'
                            plan={plan}
                            workouts={workouts}
                            isDetails={true}
                          ></TrainingPlanModal>
                          <TrainingPlanModal
                            icon='/thumbnails/modify.svg'
                            backgroundColorValue='white'
                            isHoveringColor='#D0D5DD'
                            borderValue='none'
                            extraStyleType='color'
                            extraStyleValue='white'
                            plan={plan}
                            workouts={workouts}
                          ></TrainingPlanModal>
                          <DeleteModal
                            subtitle={`Remove plan "${plan.title}"`}
                            endpoint={`training-plans/${plan.id}`}
                            redirect={"/trainer/plans"}
                          ></DeleteModal>
                        </Stack>
                      </td>
                    </tr>
                  );
                }) : <React.Fragment />}
              </tbody>
            </table>
          </div>
          <div className='flex flex-row items-center justify-center p-6 w-full'>
            <Pagination></Pagination>
          </div>
        </div>
      </div>
    </>
  );
};

function renderSkillLevel(skillLevel) {
  if (skillLevel === "Beginner") {
    return (
      <Chip
        label={skillLevel}
        style={{
          backgroundColor: "#EDFCF2",
          color: "#3B7C0f",
        }}
      />
    );
  } else if (skillLevel === "Intermediate") {
    return (
      <Chip
        label={skillLevel}
        style={{
          backgroundColor: "#EEF4FF",
          color: "#6172F3",
        }}
      />
    );
  } else {
    return (
      <Chip
        label={skillLevel}
        style={{
          backgroundColor: "#FFF1F3",
          color: "#C01048",
        }}
      />
    );
  }
}

export default PlansList;
