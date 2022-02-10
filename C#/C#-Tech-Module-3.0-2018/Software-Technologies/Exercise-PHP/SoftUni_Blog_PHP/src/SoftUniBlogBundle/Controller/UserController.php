<?php

namespace SoftUniBlogBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use SoftUniBlogBundle\Entity\User;
use SoftUniBlogBundle\Form\UserType;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;

use SoftUniBlogBundle\Entity\Article;
use SoftUniBlogBundle\Form\ArticleType;

class UserController extends Controller
{
    /**
     * @Route("register", name="user_register")
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     * @throws \LogicException
     */
    public function registerAction(Request $request)
    {
        $user = new User();
        $form = $this->createForm(UserType::class, $user);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()){
            $password = $this->get('security.password_encoder')
                ->encodePassword($user, $user->getPassword());
            $user->setPassword($password);

            $em = $this->getDoctrine()->getManager();
            $em->persist($user);
            $em->flush();

            $this->addFlash('success', 'You are registered successfully!');
            return $this->redirectToRoute('security_login');

        }
        elseif ($form->isSubmitted() && !$form->isValid()){

            $this->addFlash('success', 'You are not registered! Username exist or passwors doesnot match!');
            return $this->render('user/register.html.twig',[
                'form'=>$form->createView()
            ]);

        }

        return $this->render('user/register.html.twig',[
            'form'=>$form->createView(),
        ]);
    }

    /**
     * @Route("/profile", name="user_profile")
     *
     * @return Response
     */
    public function profileGet(){

        $user = $this->getUser();

        return $this->render('user/profile.html.twig', [
            'user'=>$user
        ]);
    }
}
