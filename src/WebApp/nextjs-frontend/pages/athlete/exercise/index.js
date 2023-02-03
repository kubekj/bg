import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";
import ExercisesList from "../../../components/athlete/training/exercises/exercises-list";

export async function getServerSideProps(context) {
  const session = await getSession({ req: context.req });

  if (!session) {
    return {
      redirect: {
        destination: "/auth/login",
        permanent: false,
      },
    };
  }

  const options = {
    headers: {
      Authorization: `Bearer ${session.jwt}`,
    },
  };

  const response = await fetcher("exercises", options);

  return {
    props: { exercises: response },
  };
}

const ExercisePage = ({ exercises, jwt }) => {
  return <ExercisesList exercises={exercises} />;
};

export default ExercisePage;

ExercisePage.layout = Athlete;
