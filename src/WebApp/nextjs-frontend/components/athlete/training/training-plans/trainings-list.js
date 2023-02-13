import style from "./trainings-list.module.css";
import React from "react";
import DeleteModal from "../../../reusable/delete-modal";
import { Stack } from "@mui/system";
import { Chip, Pagination } from "@mui/material";
import TrainingPlanModal from "../../modals/training-plan-modal";
import TrainingPlanPreview from "./training-preview-dialog";
import Button from "../../../reusable/button";
import Link from "next/link";

const TrainingsList = ({ plans }) => {
  return (
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
            <div className='relative w-full px-4 max-w-full flex-grow flex-1 text-right'></div>
          </div>
        </div>
        <div className='block w-full overflow-x-auto'>
          <table className='items-center w-full bg-transparent border-collapse'>
            <thead className='thead-light bg-indigo-400 text-white'>
              <tr>
                <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Name
                </th>
                <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Duration
                </th>
                <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  No. of workouts
                </th>
                <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Purchase Date
                </th>
                <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Skill Level
                </th>
                <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Author
                </th>
                <th className='px-6 bg-blueGray-50 text-blueGray-500 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left min-w-140-px'></th>
              </tr>
            </thead>
            <tbody className='divide-y divide-gray-200'>
              {(plans && plans.length !==0) ? plans.map((plan) => {
                return (
                  <tr key={plan.id}>
                    <td className='text-xs p-4'>{plan.title}</td>
                    <td className='text-xs p-4'>{plan.duration}</td>
                    <td className='text-xs p-4'>{plan.noOfWorkouts}</td>
                    <td className='text-xs p-4'>{plan.title}</td>
                    <td className='text-xs p-4'>
                      {renderSkillLevel(plan.skillLevel)}
                    </td>
                    <td className='text-xs p-4'>{plan.creatorEmail}</td>
                    <td className='border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 grid justify-items-end'>
                      <Stack
                        direction='row'
                        spacing={2}
                        className='items-center'
                      >
                        <Link
                          href={{
                            pathname: `/athlete/training/plan`,
                            query: { id: plan.id },
                          }}
                          style={{ textDecoration: "none" }}
                        >
                          <Button
                            iconSrc='/thumbnails/copy-outline.svg'
                            borderValue='none'
                            backgroundColorValue='#FFFFFF'
                            isHoveringColor='#C7D7FE'
                            extraStyleType='color'
                            extraStyleValue='white'
                          />
                        </Link>
                      </Stack>
                    </td>
                  </tr>
                );
              }) :
                  <React.Fragment />
              }
            </tbody>
          </table>
        </div>
        <div className='flex flex-row items-center justify-center p-6 w-full'>
          <Pagination></Pagination>
        </div>
      </div>
    </div>
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

export default TrainingsList;
